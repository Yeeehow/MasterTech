using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MasterTechParallelMAUI.Views.AI
{
    public partial class AiPage : ContentPage
    {
        // Collection the UI binds to (name avoids clash with MessagesView control)
        public ObservableCollection<ChatMessage> Messages { get; } = new();

        public AiPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Initial greeting
            Messages.Add(new ChatMessage
            {
                Message = "Hello! I'm Coles AI Assistant. I can help you navigate aisles, recommend products, plan meals, and more. What can I help you with?",
                IsUser = false
            });
        }

        private void OnSuggestedQuestionClicked(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                AddUserMessage(b.Text);
                AddBotResponse(b.Text);
                ScrollToEnd();
            }
        }

        private void OnSendMessage(object sender, EventArgs e)
        {
            var text = UserInput.Text?.Trim();
            if (string.IsNullOrEmpty(text)) return;

            AddUserMessage(text);
            AddBotResponse(text);
            UserInput.Text = string.Empty;
            ScrollToEnd();
        }

        private void AddUserMessage(string text) =>
            Messages.Add(new ChatMessage { Message = text, IsUser = true });

        private void AddBotResponse(string userInput)
        {
            string reply = userInput.ToLower() switch
            {
                string s when s.Contains("dairy") =>
                    "You'll find dairy products in aisle 3, next to the yogurt section.",
                string s when s.Contains("special") =>
                    "This week’s specials include discounts on milk, cheese, and pasta!",
                string s when s.Contains("gluten") =>
                    "Yes—gluten-free bread is in the health food aisle (section 7).",
                string s when s.Contains("snack") =>
                    "Try mixed nuts, protein bars, and fruit cups for healthier snacks.",
                _ => "I’m not sure yet, but I’m learning! Try asking about products, specials, or healthy options."
            };

            Messages.Add(new ChatMessage { Message = reply, IsUser = false });
        }

        private void ScrollToEnd()
        {
            if (Messages.Count > 0)
                MessagesView.ScrollTo(Messages[^1], position: ScrollToPosition.End, animate: true);
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; } = "";
        public bool IsUser { get; set; }
    }
}
