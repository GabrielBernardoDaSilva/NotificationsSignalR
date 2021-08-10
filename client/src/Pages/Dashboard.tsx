import { HubConnectionBuilder } from '@microsoft/signalr';
import React, { useEffect, useState } from 'react'
import { ICharData } from '../models/models';


const connection = new HubConnectionBuilder().withUrl("http://localhost:5000/dashboard").build();

const Dashboard = () => {
    const [data, setData] = useState<ICharData[]>([]);

    useEffect(() => {

        connection.start().then(() => { }).then(() => {

            connection.invoke("SendChartsUpdate").catch(err => console.log(err));
        }).catch((err) => console.log(err));
        connection.on("ReceiveChartsUpdate", (charts) => {
            console.log(charts);
            setData(charts);
        });
    }, [])


    return (
        <div>
            {data.map((item) => (
                <>
                    <div>
                        <label key={item.id! * 100}>Category: {item.category}</label>
                        <br/>
                        <label key={item.id}>Value: {item.value}</label>
                    </div>
                    <br/>
                </>
            ))}
        </div>
    )
}

export default Dashboard
