from splashkit import *


chat = create_conversation()

question = (
    "Which is heavier, one kilogram of steel or one kilogram "
    "of feathers? Explain briefly."
)

write_line("Question: " + question)
write_line("")
write_line("Thinking:")

# Send the question to the language model
conversation_add_message(chat, question)

showing_thoughts = True

while conversation_is_replying(chat):
    # Separate thinking content from the final reply
    if showing_thoughts and not conversation_is_thinking(chat):
        write_line("")
        write_line("")
        write_line("Final reply:")
        showing_thoughts = False

    write(conversation_get_reply_piece(chat))

write_line("")
write_line("")
write_line("Reply complete.")

free_conversation(chat)