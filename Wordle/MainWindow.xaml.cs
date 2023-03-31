using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rand = new Random();
        static string json = new WebClient().DownloadString("https://localhost:7082/api/Values/Get5CharNames");
        static  string[] names = json.Split(',');

        int ran = rand.Next(names.Length);
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show("The rules, ( ) means right position , { } means letter is in word and * * mean not in word at all");
            txtResult.Document.Blocks.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           
            string guess = txtGuess.Text;
            string correctword = names[ran].Trim(new Char[] { '"', '[', ']' });
            count++;
            if (guess.Length == 5)
            {
                if(guess == correctword )
                {
                    MessageBox.Show("You guessed the right name: " + correctword);
                    ran = rand.Next(names.Length);
                    txtResult.Document.Blocks.Clear();
                    txtGuess.Clear();
                } else 
                {
                    for (int i = 0; i < correctword.Length; i++)
                    {
                        if (correctword[i] == guess[i])
                        {
                          
                    
                            txtResult.Selection.Text += "\t(" + guess[i] + ")";
                           
                        } 
                        else
                        {
                            if (correctword.Contains(guess[i]))
                            {


                               
                                txtResult.Selection.Text += "\t{"+ guess[i] + "}";
                            } 
                            else
                            {

                                txtResult.Selection.Text += "\t*"+ guess[i] + "*";
                            }
                        }

                        if (i == correctword.Length - 1)
                        {
                           
                            txtResult.Selection.Text += "\n";
                            
                        }
                    }
                }
            } 
            else
            {
                MessageBox.Show("The word you guessed is either too short/long, try again");
                txtGuess.Clear();
            }

            if(count == 5 && correctword != guess)
            {
                count = 0;
                MessageBox.Show("You have reached your guesses , the answer is " + correctword);
                txtResult.Document.Blocks.Clear();
                txtGuess.Clear();
                ran = rand.Next(names.Length);
            }



        }
    }
}
