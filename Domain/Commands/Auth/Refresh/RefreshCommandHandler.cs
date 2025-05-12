using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.Configuration.Cache;
using SharedKernel.Configuration.Security.JWT;
using SharedKernel.SharedObjects;
using UserJWT = APIs.Security.JWT.User;

namespace Domain.Commands.Auth.Refresh
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, FormularioResponse<RefreshCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AccessManager _accessManager;
        private readonly ICacheProvider _cacheProvider;
        private string _tokenMessage = "OK";
        private readonly TimeSpan _credentialsCacheExpiry = new TimeSpan(25, 0, 0);
        private FormularioResponse<RefreshCommand> _response = new FormularioResponse<RefreshCommand>(0);

        public RefreshCommandHandler(IUnitOfWork unitOfWork, AccessManager accessManager, ICacheProvider cacheProvider, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _accessManager = accessManager;
            _cacheProvider = cacheProvider;
        }

        public async Task<FormularioResponse<RefreshCommand>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {           
            var redisIdToken = request.IdUser;

            var _user = new UserJWT { UserID = request.IdUser.ToString(), Password = "", Name = request.UserName };

            var credentials = await _unitOfWork.FunctionUserRepository.GetCredential(request.IdUser);

            await _cacheProvider.SetAsync(redisIdToken.ToString(), credentials, _credentialsCacheExpiry);
            var token = _accessManager.GenerateToken(_user, redisIdToken);

            token.Message = _tokenMessage;
            _response = new FormularioResponse<RefreshCommand>(0, new RefreshCommand(token));

            return _response;
        }
    }
}
