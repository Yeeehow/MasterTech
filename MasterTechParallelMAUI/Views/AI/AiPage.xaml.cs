using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MasterTechParallelMAUI.Views.AI
{
    public partial class AiPage : ContentPage
    {
        // Observable collection to store the chat messages dynamically
        private ObservableCollection<string> _chatMessages;

        public AiPage()
        {
            InitializeComponent();
            _chatMessages = new ObservableCollection<string>();
            // Bind the chat messages to the ListView content
            ChatMessages.ItemsSource = _chatMessages;
        }

        // Handle the send button click event
        private void OnSendMessage(object sender, EventArgs e)
        {
            var userMessage = UserInput.Text;

            if (!string.IsNullOrEmpty(userMessage))
            {
                // Display the user's message in the chat
                _chatMessages.Add($"You: {userMessage}");

                // Simulate bot response (for now, you can connect to an AI service or API later)
                var botResponse = "I'm not sure about that. Let me check for you!";
                _chatMessages.Add($"Bot: {botResponse}");

                // Clear the input field after sending the message
                UserInput.Text = string.Empty;
            }
        }
    }
}
