# Send & Cancel Scheduled SMS with C# and .NET

### Send

Now that you have a Twilio phone number and Messaging Service, you can get started with the .NET application. Open your preferred shell, then run these commands to create a new folder ScheduleSmsDotNet and navigate to it:

``
mkdir ScheduleSmsDotNet
cd ScheduleSmsDotNet
``

Next, use the .NET CLI to create a new console project:

``
dotnet new console
``

You can use the Twilio SDK for C# and .NET to easily interact with Twilio's APIs. Add the Twilio SDK using the Twilio NuGet package by running the command below:

``
dotnet add package Twilio
``

At the time of writing this, the version of the Twilio NuGet package is 5.70.0. Earlier versions will not contain the new APIs for scheduling messages.

*PROGRAM.CS WILL BE IN THE "CODE" SECTION OF THE PROJECT*

This application fetches the Twilio Account SID, the Twilio Auth Token, the SID of your Messaging Service, and your phone number from the environment variables. It then initializes the TwilioClient using the Account SID and Auth Token to authenticate. Lastly, it sends an SMS immediately to your phone number from the phone number you configured in your Messaging Service.

Before you can run this program, you'll need to set those environment variables. Switch back to your shell and use the following commands to set the environment variables.

*IF YOU ARE USING BASH OR A SIMILAR SHELL, POWERSHELL, CMD, LOOK IN "CODE"*

Make sure to replace the placeholders in the script above. The first two placeholders are your Twilio “ Account SID ” and your “ Auth Token ”. You can find them in the dashboard of the main page of the Twilio Console, under “Account Info”:

![image](https://user-images.githubusercontent.com/86452055/152625395-42e50ec3-fa4e-4ef4-93b7-2af0318bb1d9.png)

The ``[TWILIO_MESSAGING_SERVICE_SID]`` placeholder is the SID assigned to the Messaging Service. You can find it in the Messaging Services page of the Twilio Console. This identifier starts with the letters MG.

Now that the environment variables are present, you can run the application using the .NET CLI:

``
dotnet run
``

If all goes well, you'll receive an SMS on your phone and the application outputs something looking like this: Message SID: SM54a40e2fc2b443fb97b514ab79d36127.

To schedule an SMS to be sent in the future, you'll need to add two extra parameters to the MessageResource.Create method. To do that, update Program.cs, by adding the highlighted lines in the code below:

*LOOK IN "CODE" AGAIN !*

The sendAt parameter specifies when the message will be sent. The parameter expects an instance of DateTime and it has to be expressed using Coordinated Universal Time (UTC).

Any scheduled message has to be scheduled at least later than 1 hour (3600 seconds) from now, and before 7 days from now. There is a delay between when the DateTime instance is created and when Twilio receives the MessageResource on their servers. For example, if you create a DateTime exactly 3600 seconds from now, by the time Twilio receives your API request, the DateTime may be 2599 or fewer seconds from now. In that case, the Twilio API will reject your request.

To make sure your scheduled message is within the supported range, you can account for the delay if needed, by adding extra seconds or a minute to your DateTime.

Lastly, the scheduleType parameter configures the type of scheduling that you want to use. At the time of writing, Fixed is the only available enum value.

To test out your application, run your project again:

``
dotnet run
``

The output should be the same, but you will not receive a text message immediately. You'll have to wait 61 minutes to receive the message. However, in the meantime, you can view the message in the Programmable Messaging Logs section of the Twilio Console, under which the message will show with its status set to “ Scheduled ” until the time of delivery.

![image](https://user-images.githubusercontent.com/86452055/152625520-2d63b693-5f12-49de-824e-b9297f3bf850.png)

When the hour passes and your SMS is delivered, the status of the message will change to “ Delivered ”. You will also be able to see your Twilio phone number as the sender.

### Cancel

If at some point you need to cancel a scheduled message, you can do so as long as it hasn't been delivered yet.

To try this out, update your Program.cs file as follows:

*LOOK IN "CODE" LOL*

The application will now ask you if you want to schedule a message. If you enter 'y', it will schedule the message as before. Then, it will ask if you want to cancel a scheduled message. If you enter 'y', it will ask you for the SID of the message. If you enter the message SID, it will go ahead and cancel the scheduled message, by updating the status to Canceled on line 31.

Run the application again:

``
dotnet run
``

Enter 'y', then copy the SID of the newly scheduled message, enter 'y' again, and then paste in the message SID. The application will now cancel the scheduled message.
