import React, {FormEvent, useState} from 'react';
import styled from 'styled-components';
import {IMessage} from "../models/message";

export const Sender: React.FC = ()=> {
    const [value, setValue] = useState<string>('');

    const sendMessage = async()=>{
        const message: IMessage = {
            text: value,
        };
        const res = await fetch("/api/messages", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(message)}
        );
        if (res.ok)
        {
            setValue('');
        }
    }
    
    const submit = (ev: FormEvent<HTMLFormElement>) => {
        ev.preventDefault();
        sendMessage();
    }

    return <StyledSender>
        <form onSubmit={submit}>
            <label>Message</label>
            <input type="text" value={value} onChange={(x) => setValue(x.target.value)} className="message"/>
            <input type="submit" value="Send"/>
        </form>
    </StyledSender>;
}

const StyledSender = styled.div`
    .message {
        display:block;
        width: 200px;
        margin: 10px 0;
     }
`;