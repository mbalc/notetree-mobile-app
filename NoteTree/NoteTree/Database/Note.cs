using SQLite;
using System;

namespace NoteTree
{
    public class Note : ICloneable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ParentID { get; set; } = 0;
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

        public Note (int ID, string Content)
        {
            this.ID = ID;
            this.Content = Content;
        }
        public Note () {}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
