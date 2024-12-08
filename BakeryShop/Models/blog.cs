namespace BakeryShop.Models
{
    public class blog
    {
        public blog (String title , String img , String date) {
            this.title = title;
            this.img = img;
            this.date = date;
        }
        public String title { get; set; }
        public String img { get; set; }
        public String date { get; set; }
    }
}
