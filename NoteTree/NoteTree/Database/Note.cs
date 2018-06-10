using SQLite;
using System;

namespace NoteTree
{
    public class Note
    {
        public Note ()
        {
            ID = 0;
            Content = "test " + DateTime.Now;
            //Parent = null;
        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Content { get; set; }
        //public DateTime Created { get; set; } = DateTime.Now;
        //public DateTime Updated { get; set; } = DateTime.Now;

        //TODO many-to-one
        //public Entry Parent { get; set; }
    }
}
