#!/usr/bin/python
#coding=utf-8
import socket
import os
#onlinestatus
File_OnlineStatus = open("ra3online.OnlineStatus.config","r+")
Config_OnlineStatus = File_OnlineStatus.read()
#currectversion
File_CurrectVersion = open("ra3online.CurrectVersion.config","r+")
Config_CurrectVersion = File_CurrectVersion.read()
#socket info
socketserver = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
host = '127.0.0.1'
port = 5540
#bind socket and listen
socketserver.bind((host,port))
while True:
	socketserver.listen(5)
	clientsocket,address = socketserver.accept()
	recvmsg = clientsocket.recv(1024)
	strData = str(recvmsg)
	print (strData)
	#check onlinestatus
	if strData == 'CHECK':
		clientsocket.send(str(Config_OnlineStatus))
		print ('Send'+Config_OnlineStatus)
	#check currectversion
	if strData == 'VERSION':
		clientsocket.send(str(Config_CurrectVersion))
		print ('Send'+Config_CurrectVersion)
	
clientsocket.close()
File_OnlineStatus.close()