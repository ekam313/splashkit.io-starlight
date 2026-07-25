using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Conversation chat = CreateConversation();

string question =
    "Which is heavier, one kilogram of steel or one kilogram " +
    "of feathers? Explain briefly.";

WriteLine("Question: " + question);
WriteLine("");
WriteLine("Thinking:");

// Send the question to the language model
ConversationAddMessage(chat, question);

bool showingThoughts = true;

while (ConversationIsReplying(chat))
{
    // Separate thinking content from the final reply
    if (showingThoughts && !ConversationIsThinking(chat))
    {
        WriteLine("");
        WriteLine("");
        WriteLine("Final reply:");
        showingThoughts = false;
    }

    Write(ConversationGetReplyPiece(chat));
}

WriteLine("");
WriteLine("");
WriteLine("Reply complete.");

FreeConversation(chat);