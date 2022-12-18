using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;


namespace WindowsFormsApp1
{
   
    public partial class Form1 : Form
    {
        public TelegramBotClient botClient = new TelegramBotClient("5672061389:AAFOJCuvMxIq9AWVC8ve1KHLH0kjSsezDP8");
        public Form1()
        {
            InitializeComponent();
         
        }
        private bool button1WasClicked = false;


        [Obsolete]
        private void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            
            if(e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text == "Привіт")
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Привіт, Відкрий меню та обери завдання для подальшої роботи");

                }
                if (e.Message.Text.StartsWith("/start"))
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "Привіт, давай знайомитись, надішли 'Привіт' для початку");
                }
                if (e.Message.Text.StartsWith("/1"))
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Chat.FirstName);
                }
                if (e.Message.Text.StartsWith("/2"))
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Chat.Username);
                }
                if (e.Message.Text.StartsWith("/3"))
                {
                    botClient.SendContactAsync(e.Message.Chat.Id, "+380680549249","Vitaliy");
                }
                if (button1WasClicked == true)
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, textBox1.Text);
                }
                //botClient.SendTextMessageAsync(e.Message.Chat.Id, "Hello " +e.Message.Chat.FirstName);
                //e.Message.Contact.FirstName
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

            botClient.StartReceiving();
            botClient.OnMessage += Bot_OnMessage;


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            botClient.StopReceiving();
        }
        
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1WasClicked = true;
            botClient.OnMessage -= Bot_OnMessage;
            botClient.OnMessage += Bot_OnMessage;
        }

          

        private void button1_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
        }
    }
}
