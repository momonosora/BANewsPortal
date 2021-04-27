namespace Core.Entities
{
    public class News : BaseEntity
    {
        
        // public string Date {get;set;}
        public string Title {get;set;}
        public string Text {get;set;}
        public string PictureUrl {get;set;}
        public NewsCat NewsCat {get;set;}
        public int NewsCatId {get;set;}

    }
}