using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using OpenAI_API;
using OpenAI_API.Chat;
using System;
using OpenAI_API.Models;

public class OpenAIController : MonoBehaviour
{
    public TMP_Text textField;
    public TMP_InputField inputField;
    public Button okButton;

    private OpenAIAPI api;
    private List<ChatMessage> messages;

    void Start()
    {
        api = new OpenAIAPI(""); //* put in api key should be kept secret**
        StartConversation();
        okButton.onClick.AddListener(() => GetResponse());
    } 
  
    private void StartConversation()
    {
        messages = new List<ChatMessage> {
            new ChatMessage(ChatMessageRole.System, "You are a therapist. Keep your responses short and to the point.")
        };

        inputField.text = "";
        string startString = "talk to therapist.";
        textField.text = startString;
        Debug.Log(startString);
    }

    private async void GetResponse()
    {
        if (inputField.text.Length < 1)
        {
            return;
        }

        //disable the OK button
        okButton.enabled = false;

        // fill the user message from the input field
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            //limit messages to 100 characters
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }

        Debug.Log(string.Format("{0}: {1}", userMessage.rawRole, userMessage.Content));

        //Add the message to the list
        messages.Add(userMessage);

        //uptae the text field with the user message
        textField.text = string.Format("You: {0}", userMessage.Content);

        // clear the input field
        inputField.text = "";

        // send the entire chat to get the next message
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1, //between 0 and 1, the response creativity factor; 0 = confident, 1 = wild
            MaxTokens = 50,
            Messages = messages
        });

        // Get the response message
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.rawRole, responseMessage.Content));

        //add the response to the list of messages
        messages.Add(responseMessage);

        //Update the text field with the responses
        textField.text = string.Format("You: {0}\n\nTherapist: {1}", userMessage.Content, responseMessage.Content);

        // re-enable the ok button
        okButton.enabled = true;
    }
}
