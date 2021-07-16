using System;
using System.Collections.Generic;

namespace Code_Assignment
{
    
    public class Program
    {

        public static IDictionary<string, int> availableProducts = new Dictionary<string, int>(){
            {"headstone", 120},
            {"base", 60},
            {"vase", 20},
            {"dowel", 5}
        };

        public static string CheckPromotions(Dictionary<string, double> basket)
        {
            string promoCodes = "";
            Dictionary<string, double> basketCopy = new Dictionary<string, double>(basket);
            if (basketCopy["headstone"] > 0) {promoCodes = promoCodes + "Headstone 10 % off-";}
            while (true)
            {
                if (basketCopy["headstone"] > 0 && basketCopy["base"] > 0 && basketCopy["dowel"] > 1)
                {
                    promoCodes = promoCodes + "2 dowels for half price-";
                }
                else {break;}
                basketCopy["headstone"]--;
                basketCopy["base"]--;
                basketCopy["dowel"] = basketCopy["dowel"] - 2;
            }
            return promoCodes;
        }

        public static Dictionary<string, double> ApplyPromotions(String promoCodes, Dictionary<string, double> basket)
        {
            string[] promoCodesArray = promoCodes.Split("-");
           
            foreach (string promoCode in promoCodesArray)
            {
                if (promoCode.Equals("2 dowels for half price"))
                {                   
                    basket["dowel"]--; 
                }
                if (promoCode.Equals("Headstone 10 % off"))
                {
                    basket["headstone"] = basket["headstone"] - basket["headstone"] * 0.1 ;
                }
            }
            
            return basket;
        }
        public static double CalculateSum (Dictionary<string, double> basket)
        {
            double sum = 0;            
            foreach (var item in basket)
            { 
                sum = sum + availableProducts[item.Key] * item.Value;
            }
            return sum;
        }

        public static string MainMethod(string[] shoppingList)
        {
            string result = "";
            Dictionary<string, double> basket = new Dictionary<string, double>()
            {
                { "headstone", 0 },
                { "base", 0},
                { "dowel", 0 },
                { "vase", 0 }
            };
            foreach (string item in shoppingList)
            {
                basket[item]++;
            }
            
            Dictionary<string, double> basketCopy = new Dictionary<string, double>(basket);
            string[] promotions = CheckPromotions(basketCopy).Split("-");
            result = result + "Subtotal: £" + CalculateSum(basket) + "\n";
            foreach (string promotion in promotions)
            {
                if (promotion.Equals("Headstone 10 % off"))
                {
                    result = result + promotion + ": -£" + (availableProducts["headstone"] * 0.1 * basket["headstone"]) + "\n";
                }
                if (promotion.Equals("2 dowels for half price"))
                {
                    result = result + promotion + ": -£" + availableProducts["dowel"] + "\n";
                }
            }           
            result = result + "Total: £" + CalculateSum(ApplyPromotions(CheckPromotions(basketCopy), basketCopy));
            return result;
        }

        static void Main(string[] args)
        {
            string[] order = new string[] { "headstone", "base" };
            Console.WriteLine(MainMethod(order));
        }
    }
}
