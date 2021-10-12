/*Class purpuse: this class is for drinks, which have several states to record the drinks information
 * and some methods to get the drinks information.
 * Author:Dan 
 * Time:2021-04-20

 **/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDemo
{
    class Drink
    {
        //the instance variables 
        //id records which kind of drink 
        private int id;
        private String drinkName;
        //the variable smallSize records the size of the drinks, the default value is small
        private Boolean smallSize=true;
        //the varable ice records the ice of the drinks, the default value is with ice
        private Boolean ice= true;
        //toppingNum records the topping added in the drink  
        private int toppingNum;
        //topping list of the drink
        private Object[] toppingList;
        //the original price before take some topping 
        private double originalPrice;
        //the single drink's price 
        private double singlePrice;
        //return the single drink's price times their quantity
        private double totalPrice;
        private int quantity;

        //constructor
        public Drink(int id, int toppingNum,Boolean ice,Boolean smallSize,int quantity) {

            //assign the drink name and the original price before adding toppings and change size 
            if (id == 1)
            {
                drinkName = "Pearl Milk Tea";
                originalPrice = 4.7;
                
            }
            else if (id == 2)
            {
                drinkName = "Sago Taro Milk Tea";
                originalPrice = 5.0;
            }
            else if (id == 3)
            {
                drinkName = "Red Bean Matcha";
                originalPrice = 5.2;
            }
            else if (id == 4)
            {
                drinkName = "Bubble Gaga";
                originalPrice = 4.7;
            }

            if (!smallSize) {
                originalPrice += 0.5;
            }

            
            //assignment the other states of the drink
            this.smallSize = smallSize;
            this.ice = ice;
            this.toppingNum = toppingNum;
            this.quantity = quantity;
            singlePrice = originalPrice + (0.5 * toppingNum);
            totalPrice = singlePrice * quantity;


        }

        
        //getter for every states
        public Object[] getToppingList() {

            return toppingList;
        }

        
        public int getToppingNum() {
            return toppingNum;
        }
        public String getDrinkName() {

            return drinkName;
        }

        public String getIce() {
            if (ice) {
                return "Less Ice";
            }
            else
            return "No Ice";
        }

        public String getSize()
        {
            if (smallSize)
            {
                return "Small Size";
            }
            else
                return "Large Size";
        }

        public int getQuantity() {
            return quantity;
        
        }

        public double getTotalPrice() {
            return totalPrice;
        
        }

        public double getSinglePrice() {
            return singlePrice;
        }

        public double getOriginalPrice() {

            return originalPrice;
        }








    }
}
