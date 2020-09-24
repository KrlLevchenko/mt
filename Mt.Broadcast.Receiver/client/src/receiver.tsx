import React, {useEffect, useState} from "react";
import {IMessage} from "../models/message";


export const Receiver: React.FC = ()=>{
    const [messages, setMessages] = useState<IMessage[]>([]);
    
    const receiveMessages = async()=>{
        const response = await fetch('/api/messages');
        if (response.ok){
            const messagesFromServer: IMessage[] = await response.json();
            setMessages(messagesFromServer);
        }        
    }
    
    useEffect(()=>{
        receiveMessages();
    });    
    
    return <>
        <input type="button" value="Refresh" onClick={receiveMessages}/>
        {!!messages.length && <ul>
            {messages.map(m=><li>{m.date} {m.text}</li>)}
        </ul>}
        </>;
} 