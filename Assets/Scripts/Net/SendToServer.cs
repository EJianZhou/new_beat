using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using Beatsgame;
using System;

public class SendToServer
{
    public static int bufferlength = 0;
    public static byte[] buffer = new byte[1 << 16];
    
    static Operation opMsg = new Operation();
    public static void AddMsgToQueue(Login login)
    {
        Byte[] sendMsg = new Byte[1234];
        Byte[] msgLen = new Byte[3];
        Byte[] msgType = new Byte[1];
        int len = login.CalculateSize();
        msgLen = intToBytes(len,3);
        Debug.Log(len);
        msgType = intToBytes(1,1);
        msgLen.CopyTo(sendMsg, 0);
        msgType.CopyTo(sendMsg, 3);
        login.ToByteArray().CopyTo(sendMsg, 4);
        //SocketInfo.clientSocket.Send(sendMsg, len+4, 0);
        sendMsg.CopyTo(buffer, bufferlength);
        bufferlength += 4 + len;
    }

    public static void AddMsgToQueue(Match match)
    {
        Byte[] sendMsg = new Byte[1234];
        Byte[] msgLen = new Byte[3];
        Byte[] msgType = new Byte[1];
        int len = match.CalculateSize();
        msgLen = intToBytes(len,3);
        msgType = intToBytes(3,1);
        msgLen.CopyTo(sendMsg, 0);
        msgType.CopyTo(sendMsg, 3);
        match.ToByteArray().CopyTo(sendMsg, 4);
        //SocketInfo.clientSocket.Send(sendMsg, len+4, 0);
        sendMsg.CopyTo(buffer, bufferlength);
        bufferlength += 4 + len;
    }

    public static void AddMsgToQueue(Operation operation)
    {
        Byte[] sendMsg = new Byte[1234];
        Byte[] msgLen = new Byte[3];
        Byte[] msgType = new Byte[1];
        operation.Frame=1;
        int len = operation.CalculateSize();
        msgLen = intToBytes(len,3);
        msgType = intToBytes(6,1);
        msgLen.CopyTo(sendMsg, 0);
        msgType.CopyTo(sendMsg, 3);
        operation.ToByteArray().CopyTo(sendMsg, 4);
        //SocketInfo.clientSocket.Send(sendMsg, len+4, 0);


        Operation op = new Operation();
        op.MergeFrom(sendMsg,4,operation.CalculateSize());
        for(int i=0;i<operation.CalculateSize();i++)
        {
            Debug.Log("HELLO::"+sendMsg[i+4]);
        }

        Debug.Log("HIHIHI:"+op.ClientOperation.Count);



        sendMsg.CopyTo(buffer, bufferlength);
        bufferlength += 4 + len;
    }

    public static void AddMsgToQueue(Exitgame exitgame)
    {
        Byte[] sendMsg = new Byte[1234];
        Byte[] msgLen = new Byte[3];
        Byte[] msgType = new Byte[1];
        int len = exitgame.CalculateSize();
        msgLen = intToBytes(len,3);
        msgType = intToBytes(8,1);
        msgLen.CopyTo(sendMsg, 0);
        msgType.CopyTo(sendMsg, 3);
        exitgame.ToByteArray().CopyTo(sendMsg, 4);
        //SocketInfo.clientSocket.Send(sendMsg, len+4, 0);
        sendMsg.CopyTo(buffer, bufferlength);
        bufferlength += 4 + len;
    }

    public static void SendMsgQueue()
    {
        Debug.Log("COUNT:"+opMsg.ClientOperation.Count);
        if(opMsg.ClientOperation.Count>0)
        {
            AddMsgToQueue(opMsg);
            Debug.Log(opMsg+" "+bufferlength);
            opMsg.ClientOperation.Clear();

        }
        
        SocketInfo.clientSocket.Send(buffer, bufferlength, 0);
        bufferlength = 0;
        Array.Clear(buffer, 0, buffer.Length);
    }

    public static void AddOpToPack(OP operation)
    {
        opMsg.ClientOperation.Add(operation);
    }


    public static byte[] intToBytes(int value,int length)
    {
        byte[] src = new byte[length];
        for (int i=0;i<length;i++)
        {
            src[i] = (byte)((value >> (i*8)) & 0xFF);
        }
        return src;
    }




}
