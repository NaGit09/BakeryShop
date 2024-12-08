using BakeryShop.Models;

namespace BakeryShop.Data
{
    public class homeData
    {
        public static List<menuType> GetMenuTypes ()
        {
            List<menuType> list = new List<menuType> ();
            list.Add(new menuType("Breakfast" , "cofeIcon.png" , "Start your day with energy by enjoying a hearty breakfast."));
            list.Add(new menuType("Main Dishes", "riceIcon.png", "Delight in our selection of savory main dishes to satisfy your hunger."));
            list.Add(new menuType("Drink", "drinkIcon.png", "Quench your thirst with our refreshing beverage options."));
            list.Add(new menuType("Desserts", "cakeIcon.png", "Treat yourself with our delicious desserts for a perfect finish."));

            return list;
        } 
        public static String[] getImg ()
        {
            String[] listImg = { "kebab-set-table 1.png",
                "charming-female-blowing-candles-birthday-cake-after-making-her-wish-party 1.png",
                "happy-man-wife-sunny-day 1.png",
                "group-friends-eating-restaurant 1.png" };
            return listImg;
        }
        public static String[] getImg2()
        {
            String[] listImg2 = { "mid-shot-chef-holding-plate-with-pasta-making-ok-sign 1.png",
            "sour-curry-with-snakehead-fish-spicy-garden-hot-pot-thai-food 1.png",
            "sadj-iron-pot-with-various-salads 1.png"};
            return listImg2;
        }
        public static List<blog> getBlog() {
            List<blog> blogs = new List<blog> ();
         
            blogs.Add(new blog("Golden, crispy, and perfectly seasoned, our French fries are the ultimate comfort food. ", "pexels-suzy-hazelwood-2966196 1.png", "January 3, 2023"));
            blogs.Add(new blog("Juicy, tender, and wrapped in a perfectly crispy golden coating, our fried chicken is a true delight for your taste buds.", "pexels-leonardo-luz-13998974 1.png", "January 3, 2023"));
            blogs.Add(new blog("Soft, moist, and topped with a swirl of creamy frosting, our cupcakes are miniature bites of happiness.", "pexels-sebastian-coman-photography-3791088 1.png", "January 3, 2023"));
            blogs.Add(new blog("A symphony of flavors baked to perfection, our pizza features a crispy crust, rich tomato sauce, and gooey melted cheese", "pexels-katerina-holmes-5908226 1.png", "January 3, 2023"));


            return blogs;
        }
    }
}
