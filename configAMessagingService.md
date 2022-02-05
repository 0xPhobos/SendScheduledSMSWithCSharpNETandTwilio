# Configurate a Messaging Service

Scheduled messages can only be sent from a Messaging Service at this time, so the next step is to configure a Messaging Service and add your Twilio phone number to it.

In the Twilio Console, find the “Messaging” product and click on its Services option. Then click the “Create Messaging Service” button.

On the first page of the creation process, enter a friendly name for the service, such as “Appointments”, and select “Notify my users” in the “Select what you want to use Messaging for” dropdown.

![image](https://user-images.githubusercontent.com/86452055/152624306-95e1f66f-54f5-414f-a8ce-228bea43059b.png)

Click the “Create Messaging Service” button to move to the second step. In this part of the configuration, you have to add the sender phone number(s) to the sender pool used by the service. Click the “Add Senders” button to add the Twilio phone number you acquired in the previous section.

![image](https://user-images.githubusercontent.com/86452055/152624328-fba95586-2395-492f-b470-2379db1cca58.png)

Select Phone Number in the “Sender Type” dropdown, and click “Continue”.

Add a checkmark next to the phone number you want to use as a sender, and click “Add phone numbers”.

![image](https://user-images.githubusercontent.com/86452055/152624343-1be52565-20c8-4a2b-84bd-f608173ae936.png)

Click the “Step 3: Set up integration” button to move on to the next step. You don’t have to change any of the settings on this page, just click on “Step 4: Add compliance info”.

To complete the configuration of your Messaging Service, click on “Complete Messaging Service Setup”. You will now be offered the option to send a test message.

![image](https://user-images.githubusercontent.com/86452055/152624445-f481969e-0e7b-44d1-b9a7-1fd87ffbac54.png)

It is a good idea to test that your messaging service is able to send messages, so go ahead and click on “Try sending a message”.

In the “To phone number” dropdown, select your personal number, which should be registered and verified with your Twilio account. Select the Messaging Service you just created in the “From Messaging Service SID”. Enter some text to send yourself in the “Body Text”.

![image](https://user-images.githubusercontent.com/86452055/152624453-13c42363-d287-4e65-8363-752a0e1b411c.png)

Click the “Send test SMS” button, and make sure you receive the SMS on your phone.
