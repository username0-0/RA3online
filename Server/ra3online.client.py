#!/usr/bin/python
#coding=utf-8
import socket
client = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
host = '127.0.0.1'
port = 5540
client.connect((host,port))
print("this program is only for test")
while True:
	msg = input()
	client.send(str(msg))
	getmsg = str(client.recv(1024))
	print("Get "+getmsg)
client.close()