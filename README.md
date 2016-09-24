# CollBase_IVRS
IVRS based Student Database project.

The system uses AT89S52 micrconstroller coupled with a DTMF decoder to decode the register number entered through a call. This is then relayed to the PC using UART and the application collects the register number. The application uses the register number to search in a SQL database and resultant marks are displayed on the screen.
Apart from this the result is also read out using the Text to Speech module of the PC and this can be relayed over the phone.
