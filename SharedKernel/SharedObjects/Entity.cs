using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel.SharedObjects
{
    public abstract class Entity
    {
        [Column("DT_CADASTRO", TypeName = "datetime")]
        public DateTime? CreateAt { get; private set; }

        [Column("DT_ALTERADO", TypeName = "datetime")]
        public DateTime? UpdateAt { get; private set; }

        [Column("BT_REMOVIDO", TypeName = "bit")]
        public bool Removed { get; private set; }

        public void ChangeRemoved(bool status)
        {
            UpdateAt = DateTime.Now;
            Removed = status;
        }

        public void ChangeUpdateAtToDateTimeNow()
        {
            UpdateAt = DateTime.Now;
        }

        public bool StatusRemoved()
        {
            return Removed;
        }

        protected void SetCreateAtAndUpdateAtToNow()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;

            Removed = false;
        }
    }
}
