namespace BakeryShop.Models
{
    public class menuType
    {
       public  menuType(String type , String url , String desc)
        {
            this.type = type;
            this.img = url;
            this.desc = desc;
        }
        public String type { get; set; }
        public String img { get; set; }
        public String desc { get; set; }
    }
}
