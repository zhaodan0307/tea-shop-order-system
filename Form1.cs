/*Class purpuse: this class is for drinks, which have several states to record the drinks information
 * and some methods to get the drinks information.
 * Author:Dan 
 * Time:2021-04-20
 **/


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectDemo
{
    public partial class Form1 : Form
    {
        //store the drink list of each order 
        List<Drink> drinkList;
        //the connection to the database 
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\danzh\\source\\repos\\FinalProjectDemo\\Database1.mdf;");
        //a boolean variable to store whether the person with their telephone number is member of coco, default value is true 
        Boolean haveBeenMembership = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startUp();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            
            orderProcess();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //initialize all the information for preparing to order
        private void startUp()
        {
            drinkList = null;
            receipeTextBox.Text = "";
            drinkList = new List<Drink>();
            sidePanel.Location = new Point(0, 68);
            userControl11.BringToFront();
            HomePageOrderButton.Visible = true;
            HomePageOrderButton.BringToFront();
            userControl11.Visible = true;
            CheckOut.Enabled = false;
            CheckOut.Visible = true;

            haveBeenMembership = true;
            PointNowlabel.Text = "0";
            numberOfRedeem.Text = "0";

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            foreach (int i in toppingBox1.CheckedIndices)
            {
                toppingBox1.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in toppingBox2.CheckedIndices)
            {
                toppingBox2.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in toppingBox3.CheckedIndices)
            {
                toppingBox3.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in toppingBox4.CheckedIndices)
            {
                toppingBox4.SetItemCheckState(i, CheckState.Unchecked);
            }


        }
        //order process is to showing the order page  
        private void orderProcess()
        {
            

            
            sidePanel.Location = new Point(0, 140);
            HomePageOrderButton.Visible = false;
            CheckOut.Enabled = true;
            CheckOut.Visible = true;
            userControl11.Visible = false;
            userControl21.BringToFront();
            userControl21.Visible = true;

            SizeBox1.Visible = true;
            SizeBox1.BringToFront();

            SizeBox2.Visible = true;
            SizeBox2.BringToFront();

            SizeBox3.Visible = true;
            SizeBox3.BringToFront();

            SizeBox4.Visible = true;
            SizeBox4.BringToFront();


            IceBox1.Visible = true;
            IceBox1.BringToFront();

            IceBox2.Visible = true;
            IceBox2.BringToFront();

            IceBox3.Visible = true;
            IceBox3.BringToFront();

            IceBox4.Visible = true;
            IceBox4.BringToFront();

            toppingBox1.Visible = true;
            toppingBox1.BringToFront();

            toppingBox2.Visible = true;
            toppingBox2.BringToFront();

            toppingBox3.Visible = true;
            toppingBox3.BringToFront();

            toppingBox4.Visible = true;
            toppingBox4.BringToFront();

            numericUpDown1.Visible = true;
            numericUpDown1.BringToFront();

            numericUpDown2.Visible = true;
            numericUpDown2.BringToFront();
            numericUpDown3.Visible = true;
            numericUpDown3.BringToFront();
            numericUpDown4.Visible = true;
            numericUpDown4.BringToFront();

            Submit.Visible = true;
            Submit.BringToFront();

            radioButton2.Checked = true;
            radioButton3.Checked = true;
            radioButton5.Checked = true;
            radioButton7.Checked = true;

            radioButton9.Checked = true;
            radioButton12.Checked = true;
            radioButton14.Checked = true;
            radioButton16.Checked = true;

           
            numericUpDown1.Maximum = 10;
            numericUpDown1.Minimum = 0;

           
            numericUpDown2.Maximum = 10;
            numericUpDown2.Minimum = 0;

            
            numericUpDown3.Maximum = 10;
            numericUpDown3.Minimum = 0;

           
            numericUpDown4.Maximum = 10;
            numericUpDown4.Minimum = 0;

           


        }

        //point process is to showing the point page
        private void pointProcess() {

            sidePanel.Location = new Point(0, 212);
            userControl21.Visible = false;
            userControl31.BringToFront();
            userControl31.Visible = true;

            inputLabel.Visible = true;
            inputLabel.BringToFront();

            TelephoneInput.Visible = true;
            TelephoneInput.BringToFront();

            checkPointButton.Visible = true;
            checkPointButton.BringToFront();

            pointLabel.Visible = true;
            pointLabel.BringToFront();

            PointNowlabel.Visible = true;
            PointNowlabel.BringToFront();

            RedeemButton.Visible = true;
            RedeemButton.Enabled = false;
            RedeemButton.BringToFront();

            

            RedeemNumber.Visible = true;
            RedeemNumber.BringToFront();

            numberOfRedeem.Visible = true;
            numberOfRedeem.BringToFront();

            continueButton.Visible = true;
            continueButton.BringToFront();


        }

        //showing the check out page
        public void checkOutProcess() {
            sidePanel.Location = new Point(0, 285);
            userControl31.Visible = false;
            userControl41.BringToFront();
            userControl41.Visible = true;

            panelCheckOutRight.Visible = true;
            panelCheckOutRight.BringToFront();
            ReceipePanel.Visible = true;
            ReceipePanel.BringToFront();



        }
        //to collect the information of orders and state them to the screen
        public void orderInformationReord()
        {
            int orderNum = 1;
            //if order something
            if (numericUpDown1.Value > 0)
            {
                for(int i =0;i< numericUpDown1.Value; i++)
                {

                    drinkList.Add(new Drink(1, toppingBox1.CheckedItems.Count, radioButton9.Checked, radioButton2.Checked, (int)numericUpDown1.Value));

                }
                //create Pearl Milk Tea 

                //print the name of the drink
                receipeTextBox.Text +="Order #"+ (orderNum++) +" :" +drinkList[drinkList.Count - 1].getDrinkName() + "          X"+ drinkList[drinkList.Count - 1].getQuantity()+ "\r\n";

                //print the size of the drink
                receipeTextBox.Text +="          "+ "Size:" + drinkList[drinkList.Count - 1].getSize()+ "\r\n";
                //print the ice of the drink
                receipeTextBox.Text += "          " + "Ice:" + drinkList[drinkList.Count - 1].getIce()+ "\r\n";

                receipeTextBox.Text += "          " + "topping:";
                //print the topping of the drink
                foreach (object itemChecked in toppingBox1.CheckedItems)
                {
                    
                    receipeTextBox.Text += itemChecked + ",";

                }
                receipeTextBox.Text += "\r\n" +"                  Total Price:  "+ drinkList[drinkList.Count - 1].getTotalPrice();



            }
            // if order the sago taro milk tea

            if (numericUpDown2.Value > 0)
            {
                for (int i = 0; i < numericUpDown2.Value; i++)
                {
                    //create Pearl Milk Tea 
                    drinkList.Add(new Drink(2, toppingBox2.CheckedItems.Count, radioButton12.Checked, radioButton3.Checked, (int)numericUpDown2.Value));



                }


                //print the name of the drink
                receipeTextBox.Text +="\r\n"+ "Order #" + (orderNum++) + " :" + drinkList[drinkList.Count - 1].getDrinkName() + "          X" + drinkList[drinkList.Count - 1].getQuantity() + "\r\n";

                //print the size of the drink
                receipeTextBox.Text += "          " + "Size:" + drinkList[drinkList.Count - 1].getSize() + "\r\n";
                //print the ice of the drink
                receipeTextBox.Text += "          " + "Ice:" + drinkList[drinkList.Count - 1].getIce() + "\r\n";

                receipeTextBox.Text += "          " + "topping:";
                //print the topping of the drink
                foreach (object itemChecked in toppingBox2.CheckedItems)
                {

                    receipeTextBox.Text += itemChecked + ",";

                }
                receipeTextBox.Text += "\r\n" + "                  Total Price:  " + drinkList[drinkList.Count - 1].getTotalPrice();



            }

            if (numericUpDown3.Value > 0)
            {

                for (int i = 0; i < numericUpDown3.Value; i++)
                {

                    //create Pearl Milk Tea 
                    drinkList.Add(new Drink(3, toppingBox3.CheckedItems.Count, radioButton14.Checked, radioButton5.Checked, (int)numericUpDown3.Value));

                }

                //print the name of the drink
                receipeTextBox.Text += "\r\n" + "Order #" + (orderNum++) + " :" + drinkList[drinkList.Count - 1].getDrinkName() + "          X" + drinkList[drinkList.Count - 1].getQuantity() + "\r\n";

                //print the size of the drink
                receipeTextBox.Text += "          " + "Size:" + drinkList[drinkList.Count - 1].getSize() + "\r\n";
                //print the ice of the drink
                receipeTextBox.Text += "          " + "Ice:" + drinkList[drinkList.Count - 1].getIce() + "\r\n";

                receipeTextBox.Text += "          " + "topping:";
                //print the topping of the drink
                foreach (object itemChecked in toppingBox3.CheckedItems)
                {

                    receipeTextBox.Text += itemChecked + ",";

                }
                receipeTextBox.Text += "\r\n" + "                  Total Price:  " + drinkList[drinkList.Count - 1].getTotalPrice();



            }

            if (numericUpDown4.Value > 0)
            {
                for (int i = 0; i < numericUpDown2.Value; i++)
                {
                    //create Pearl Milk Tea 
                    drinkList.Add(new Drink(4, toppingBox4.CheckedItems.Count, radioButton16.Checked, radioButton7.Checked, (int)numericUpDown4.Value));
                }


                //print the name of the drink
                receipeTextBox.Text += "\r\n" + "Order #" + (orderNum++) + " :" + drinkList[drinkList.Count - 1].getDrinkName() + "          X" + drinkList[drinkList.Count - 1].getQuantity() + "\r\n";

                //print the size of the drink
                receipeTextBox.Text += "          " + "Size:" + drinkList[drinkList.Count - 1].getSize() + "\r\n";
                //print the ice of the drink
                receipeTextBox.Text += "          " + "Ice:" + drinkList[drinkList.Count - 1].getIce() + "\r\n";

                receipeTextBox.Text += "          " + "topping:";
                //print the topping of the drink
                foreach (object itemChecked in toppingBox4.CheckedItems)
                {

                    receipeTextBox.Text += itemChecked + ",";

                }
                receipeTextBox.Text += "\r\n" + "                  Total Price:  " + drinkList[drinkList.Count - 1].getTotalPrice();



            }


        }   
            
            
        
        
        
        
        //click the homeButton,the start page is showing up and clear the last order's data to prepare to take the order
        private void HomeButton_Click(object sender, EventArgs e)
        {
            
            
            startUp();
        }

        //click the CheckOutButton,the checkout page is showing up 
        private void CheckOut_Click(object sender, EventArgs e)
        {
            checkOutProcess();
        }
        //click the pointButton,the point page is showing up 
        private void PointButton_Click(object sender, EventArgs e)
        {
            pointProcess();


        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
        ////click the HomePageOrderButton,the order page is showing up 
        private void HomePageOrderButton_Click(object sender, EventArgs e)
        {
            orderProcess();
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }

        private void toppingBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SizeBox1_Enter(object sender, EventArgs e)
        {

        }

        //pearl milk tea size large
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //pearl milk tea size small
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //sago taro size large
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        //sago taro size small
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        //red bean size large 
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        //red bean size small
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        //bubble gaga size large
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        // bubble gaga size small
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }
        //less ice pearl milk tea 
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        //no ice pearl milk tea
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }
        // less ice sago taro 
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }
        // no ice dago taro
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }
        //less ice red bean
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }
        // no ice read bean 
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        //less ice bubble gaga
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        //no ice bubble gaga
        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        //pearl milk tea topping 
        private void toppingBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void TelephoneInput_TextChanged(object sender, EventArgs e)
        {

        }
        //click the check point button to see how much point you have from the database plus the points after this order
        private void checkPointButton_Click(object sender, EventArgs e)
        {
            con.Open();
            
            String query = "SELECT Point FROM PointInformation where Telephone=@Telephone";
            PointNowlabel.Text = "0";
            numberOfRedeem.Text = "0";
            SqlCommand command = new SqlCommand(query,con);
            command.Parameters.AddWithValue("@Telephone",Convert.ToInt64((TelephoneInput.Text)));

            SqlDataReader da = command.ExecuteReader();
            int quantityOfThisOrder = (int)(numericUpDown1.Value + numericUpDown2.Value+numericUpDown3.Value+numericUpDown4.Value);
            if (da.HasRows&&da.Read()) {
                //user exist
                PointNowlabel.Text = (Convert.ToInt64(da.GetValue(0))+quantityOfThisOrder).ToString();

                //REDEEN NUMBER MUST LESS THAN OR EQUAL THE NUMBER OF BUYING 
                if (Convert.ToInt64(PointNowlabel.Text)>=10&&quantityOfThisOrder>=Convert.ToInt64( numberOfRedeem.Text)) {
                    RedeemButton.Enabled = true;
                
                }

            }
            else
            {
                MessageBox.Show("Thank you for regiseter our membership");
                PointNowlabel.Text = quantityOfThisOrder.ToString();
                haveBeenMembership = false;
                
            }

            con.Close();
        }

        //click the redeem button to showing the total point after redeem and how many you redeem in this order
        private void RedeemButton_Click(object sender, EventArgs e)
        {
            int quantityOfThisOrder = (int)(numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value);

            if (Convert.ToInt64(PointNowlabel.Text) >= 10 && quantityOfThisOrder >= Convert.ToInt64(numberOfRedeem.Text))
            {

                PointNowlabel.Text = (Convert.ToInt64(PointNowlabel.Text) - 10).ToString();
                numberOfRedeem.Text = (Convert.ToInt64(numberOfRedeem.Text) + 1).ToString();
            }
            else {
                RedeemButton.Enabled = false;
            
            }
               
        }
        //click the continueButton to go to the check out page and get the redeem number and total amount showing 
        private void continueButton_Click(object sender, EventArgs e)
        {
            checkOutProcess();
            receipeTextBox.Text += "\r\n" + "                      Redeem:" + numberOfRedeem.Text;

            getCheckOutAmount();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        //clear the order data before and collect the data of this order 
        private void Submit_Click(object sender, EventArgs e)
        {
            drinkList = null;
            drinkList = new List<Drink>();
            receipeTextBox.Text = "";
            pointProcess();
            orderInformationReord();
        }

        //update the database reinitialize the data and go back to the home page
        private void newOrderButton_Click(object sender, EventArgs e)
        {
            
            updateDatabase();
            startUp();
        }

        //get the tatal amount of the customer 
        private void getCheckOutAmount() {
            double totalPay = 0;
            foreach (Drink drink in drinkList) {
                totalPay += drink.getSinglePrice();
            }

            for (int i = 0; i < Convert.ToInt32(numberOfRedeem.Text); i++) {

                totalPay -= drinkList[drinkList.Count - 1 - i].getSinglePrice();
            
            }
            AmountNumber.Text = totalPay.ToString();


        }

        //update the information for the customer.
        private void updateDatabase() {
            con.Open();
            int newPoint = Convert.ToInt32(PointNowlabel.Text);

            if(TelephoneInput.Text != "")
            {

                if (haveBeenMembership)
                {

                    String query = "UPDATE PointInformation SET Point= @Point WHERE Telephone= @Telephone";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@Point", Convert.ToInt32((PointNowlabel.Text)));
                    command.Parameters.AddWithValue("@Telephone", Convert.ToInt64((TelephoneInput.Text)));
                    command.ExecuteNonQuery();
                }
                else
                {

                    String query = "INSERT INTO PointInformation(Telephone,Point) VALUES (@Telephone , @Point)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@Point", Convert.ToInt32((PointNowlabel.Text)));
                    command.Parameters.AddWithValue("@Telephone", Convert.ToInt64((TelephoneInput.Text)));
                    command.ExecuteNonQuery();
                }

            }
            

            con.Close();
            
        }
    }
}
