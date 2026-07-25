using SplashKitSDK;

namespace ConversationIsThinkingExample
{
    public class Program
    {
        public static void Main()
        {
            Conversation chat = SplashKit.CreateConversation();

            string question =
                "Which is heavier, one kilogram of steel or one kilogram " +
                "of feathers? Explain briefly.";

            SplashKit.WriteLine("Question: " + question);
            SplashKit.WriteLine("");
            SplashKit.WriteLine("Thinking:");

            // Send the question to the language model
            SplashKit.ConversationAddMessage(chat, question);

            bool showingThoughts = true;

            while (SplashKit.ConversationIsReplying(chat))
            {
                // Separate thinking content from the final reply
                if (
                    showingThoughts &&
                    !SplashKit.ConversationIsThinking(chat)
                )
                {
                    SplashKit.WriteLine("");
                    SplashKit.WriteLine("");
                    SplashKit.WriteLine("Final reply:");
                    showingThoughts = false;
                }

                SplashKit.Write(
                    SplashKit.ConversationGetReplyPiece(chat)
                );
            }

            SplashKit.WriteLine("");
            SplashKit.WriteLine("");
            SplashKit.WriteLine("Reply complete.");

            SplashKit.FreeConversation(chat);
        }
    }
}