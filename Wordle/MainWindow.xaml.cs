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
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show("The rules, ( ) means right position , { } means letter is in word and * * mean not in word at all");
            txtResult.Document.Blocks.Clear();
        }

         string RanAfr = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Afrikaans");
         string RanEng = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=English");
         string RanXho = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Xhosa");
        string correctword = " ";
        int count = 0;
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           
            string guess = txtGuess.Text;
            
            if (cbxLang.Text == "Afrikaans")
            {
                correctword = RanAfr;
            }else if (cbxLang.Text == "English")
            {
                correctword = RanEng;
            }
            else
            {
                correctword = RanXho;
            }
            txtGuess.Text = correctword;
            count++;
            if (guess.Length == 5)
            {
                if(guess == correctword )
                {
                    MessageBox.Show("You guessed the right name: " + correctword);
                    if (cbxLang.Text == "Afrikaans")
                    {
                        RanAfr = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Afrikaans");
                    }
                    else if (cbxLang.Text == "English")
                    {
                        RanEng = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=English");
                    }
                    else
                    {
                        RanXho = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Xhosa");
                    }
                    count = 0;
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
                        //txtGuess.Clear();
                    }
                }
            } 
            else
            {
                MessageBox.Show("The word you guessed is either too short/long, try again");
                count= 0;
                txtGuess.Clear();
            }

            if(count == 5 && correctword != guess)
            {
                if (cbxLang.Text == "Afrikaans")
                {
                    RanAfr = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Afrikaans");
                }
                else if (cbxLang.Text == "English")
                {
                    RanEng = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=English");
                }
                else
                {
                    RanXho = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Xhosa");
                }
                count = 0;
                MessageBox.Show("You have reached your guesses , the answer is " + correctword);
                txtResult.Document.Blocks.Clear();
                txtGuess.Clear();
               
            }



        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (cbxLang.Text == "Afrikaans")
            {
                RanAfr = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Afrikaans");
            }
            else if (cbxLang.Text == "English")
            {
                RanEng = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=English");
            }
            else
            {
                RanXho = new WebClient().DownloadString("https://localhost:7082/api/Values/SingleRandomWord?Select=Xhosa");
            }
            count = 0;
            txtGuess.Clear();
            txtResult.Document.Blocks.Clear();
        }

       
    }
}
