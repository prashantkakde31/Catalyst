/*
---------------------------------:::: CAUTION ::::------------------------------------

NOTE :  As Javascript is a Case Sensitive scripting language changing the case of any Function name could
			break existing projects based on this file.

*/
/*  
Functions Available in this file 
funNumber()		' accept only numeric input
funLower()		' accepts input in lower case
funUpper()		' accepts input in upper case

*/

function funUpper() 
{
	if (event.keyCode >= 97 && event.keyCode <= 122) 
	{
		event.keyCode -= 32;
	}
}

function funLower()
 {
	if (event.keyCode >= 65 && event.keyCode <= 90) 
	{
		event.keyCode += 32;
	}
}
function funCharacter() 
{
	if ((event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 8) || (event.keyCode == 32)) 
	{
		return true;
	}
	else 
	{
		event.returnValue = false;
		return false;
	}
}
function funAlphaNumeric()
 {
	if ((event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 8) || (event.keyCode > 45 && event.keyCode < 58)|| (event.keyCode == 32)) 
	{
		return true;
	}
	else 
	{
		event.returnValue = false;
		return false;
	}
}

function funNumber() 
{
	if (event.keyCode < 45 || event.keyCode > 57) 
	{
		event.returnValue = false;
		return false;
	}
}
/* SCRIPT TO CALL FOR ENTER KEY  */
function modifKey(e) 
{
   var modif=''; 
   if (event.altKey) 
   {
      modif+='[ Alt ] ';
   } 
   if (event.ctrlKey) 
   {
      modif+='[ Ctrl ] ';
   } 
   if (event.shiftKey) 
   {
      modif+='[ Shift ] ';
   } 
   getKey(e,modif); 
}
function getKey(e,modif) 
{ 
   if (e.keyCode) 
   {
      keycode=e.keyCode;
   } 
   else 
   {
      keycode=e.which;
   } 
   char=String.fromCharCode(keycode); 
   xCode=char.charCodeAt(0); 
   if (xCode == 13) //Enter key is pressed!!
   { 
      window.event.keyCode = 0; 
   } 
   else 
   { 
      return true; 
   } 
}
	