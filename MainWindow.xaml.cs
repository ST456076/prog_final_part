using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace prog_final_part
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global decleration for all insance and virables

        //generic list 
        private List<QuizeGameQuestions> quizeData;

        //variables
        private int questionIndex = 0;
        private int questionCount = 0;

        //button 
        private Button electedChoice = null;
        private Button correctAnswerButton = null;
        public MainWindow()

        {

            InitializeComponent();
            populateQuizeData(); // Call this method
            showQuiz();
        }
        //method to show the quize on the button
        private void showQuiz()
        {
            ////get the current index
            correctAnswerButton = null;
            electedChoice = null;

            //then get all the questio values 
            var currentQuize = quizeData[questionIndex];

            //display the question to the usr 
            QuestionDisplay.Text = currentQuize.Question;

            //add the choices to the button 
            var shuffled = currentQuize.Answers.OrderBy(_ => Guid.NewGuid()).ToList();

            //then add the index
            numberOne.Content = shuffled[0];
            numberTwo.Content = shuffled[1];
            numberThree.Content = shuffled[2];

            //correct one

            numberfour.Content = currentQuize.CorrectAnswer;
            ClearStyle();

        }
        //meethod to re-set the button
        private void ClearStyle()
        {
            //use for each to re-set
            foreach (var buttonChoice in new[] { numberOne, numberTwo, numberThree, numberfour })
            {
                buttonChoice.Background = Brushes.LightGray;
            }
        }

        // Method to populate  the quize data 
        private void populateQuizeData()
        {
            //store 
            quizeData = new List<QuizeGameQuestions>()
            {
                new QuizeGameQuestions
                {
                    Question= "what is malware",
                    CorrectAnswer= "software that harms ad exploits a computer system",
                    Answers = new List<string>
                    {

                        "software that protect against viruses", "software that dectats intrusion","software that harms or exploits a computer system","software that optimizes system perfomance"
                    }
                } ,
                new QuizeGameQuestions
                {
                    Question = "what shuld you do if you recive a suspios email?",
                    CorrectAnswer = "report it to IT department ",
                    Answers=new List<string>
                    {
                        "click on the link of atttachment", "reply to the email", "delete the email", "report it to IT depatment"
                    }
                } ,// end of second questin add another one

            };

        }
        //end of the method to populate data
        // when the task selected item from the list view 
        private void chat_page_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // get the selected task   
            string selected_task = chat_page.SelectedItem.ToString();
            // cheack if the tasks is not done 
            if (!selected_task.Contains("stats done"))
            {
                //get the index f the selected taxk
                int getIndex = chat_page.Items.IndexOf(selected_task);

                //eddit the selected item  
                chat_page.Items[getIndex] = selected_task + " " + "stats done";
            }
            else
            {
                //remove if it marked done
                //get the index 
                chat_page.Items.Remove(selected_task);
            }
        }

        private void chats(object sender, RoutedEventArgs e)
        {
            //olllect all the user input
            string collect_questoion = user_question.Text.ToString();

            //validate if the user entred something 
            if (!collect_questoion.Equals(""))
            {
                //hek if the user want to ad a task 
                if (collect_questoion.Contains("add task"))
                {
                    //add the task to thr list view but get date and time
                    DateTime date = DateTime.Now;
                    DateTime time = DateTime.Now.ToLocalTime();



                    //set the formart for the date 
                    string formart_date = date.ToString("yyyy/MM/dd");

                    //the ad to the list
                    chat_page.Items.Add("user : " + collect_questoion + "\n" + formart_date + "Time" + time);
                    chat_page.ScrollIntoView(chat_page.Items[chat_page.Items.Count - 1]);

                }



            }
            else
            {
                //error message
                MessageBox.Show("question field is requre!!!");
            }
        }//end of chat event handler
        private void reminder(object sender, RoutedEventArgs e)
        {




        }//end of 


        private void quiz(object sender, RoutedEventArgs e)
        {

        }
        private void HandlingAnswers(object sender, RoutedEventArgs e)
        {
            electedChoice = sender as Button;
            string selected = electedChoice.Content.ToString();

            //decler string correct 
            string correct = quizeData[questionIndex].CorrectAnswer;
            //then click if correct or not by if statement 
            if (selected == correct)
            {
                //set a button for background color 
                electedChoice.Background = Brushes.Green;
                //assign to hold 
                correctAnswerButton = electedChoice;
            }
            else
            {
                //incorrect
                electedChoice.Background = Brushes.Red;
                correctAnswerButton = electedChoice;

            }



        }//end of hadling answer section 

        //event handler for the next question 
        private void HendlingTheFllowingQuestion(object sender, RoutedEventArgs e)
        {
            //check if the user select an answer
            if (electedChoice == null)
            {
                //message 
                MessageBox.Show("pick any answer for the 4 ");
                return; // Exit early if no answer was selected
            }
            string chosen = electedChoice.Content.ToString();
            string correct = quizeData[questionIndex].CorrectAnswer;
            //cheack if correct 
            if (chosen == correct)
            {
                //add point 
                questionCount++;
                //show score
                DisplayScore.Text = "score: " + questionCount;
                //move to the next index question
            }
            else
            {
                // incorrect
                electedChoice.Background = Brushes.Red;

                // Show the correct answer in green
                foreach (var button in new[] { numberOne, numberTwo, numberThree, numberfour })
                {
                    if (button.Content.ToString() == correct)
                    {
                        button.Background = Brushes.Green;
                        break;
                    }
                }


            }
            questionIndex++;

            if (questionIndex >= quizeData.Count)
            {
                MessageBox.Show("Quiz done! Restarting from the beginning.");

                questionIndex = 0;         // Reset to first question
                questionCount = 0;         // Reset score
                DisplayScore.Text = "Score: 0";

                showQuiz();                // Show first question again
                return;
            }
            // 

            showQuiz(); // Show next question
        }


        private void activity_log(object sender, RoutedEventArgs e)
        {
         
        }

        private void exit(object sender, RoutedEventArgs e)
        {

        }

     
    }
}