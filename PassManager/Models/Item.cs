using System;
using SQLite;

namespace PassManager.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int PKey { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string InfoNumber { get; set; }
        public string Password { get; set; }
        public string InfoAdress { get; set; }
    }
}