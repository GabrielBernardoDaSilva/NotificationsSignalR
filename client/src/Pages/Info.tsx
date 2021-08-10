import { HubConnectionBuilder } from '@microsoft/signalr'
import React, { useEffect, useState } from 'react'
import { ICharData } from '../models/models';

const connection = new HubConnectionBuilder().withUrl("http://localhost:5000/dashboard").build();


const Info = () => {

    const [category, setCategory] = useState("");
    const [value, setValue] = useState("");
    const sendUpdate = () => {
        const chartData: ICharData = {
            category: category,
            value: parseInt(value)
        }
        connection.invoke("SendNewChart", chartData).catch((err) => console.log(err));
    }
    useEffect(() => {
        connection.start().then(() => {

        }).catch((err) => console.log("Error"))
    }, [])
    return (
        <>
            <div style={{ margin: "25%" }}>
                <div>
                    <label>Category: </label>
                    <input type="text" onChange={(e) => setCategory(e.target.value)} />
                </div>
                <br/>
                <div>
                    <label>Value: </label>
                    <input type="text" onChange={(e) => setValue(e.target.value)} />
                </div>
                <div style={{margin: "5%"}}>
                    <button type="button" onClick={sendUpdate}>Send</button>
                </div>

            </div>
        </>
    )
}

export default Info
