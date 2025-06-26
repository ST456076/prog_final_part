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
        public MainWindow()

        {

        InitializeComponent();
        }
        // when the task selected item from the list view 
        private void chat_page_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // get the selected task   
            string selected_task = chat_page.SelectedItem.ToString();
            // cheack if the tasks is not done 
            if (! selected_task.Contains("stats done"))
            {
                //get the index f the selected taxk
                int getIndex = chat_page.Items.IndexOf(selected_task);

                //eddit the selected item  
                chat_page.Items[getIndex] = selected_task + " "+ "stats done";
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
                if(collect_questoion.Contains("add task"))
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

        private void activity_log(object sender, RoutedEventArgs e)
        {
         
        }

        private void exit(object sender, RoutedEventArgs e)
        {

        }

     
    }
}