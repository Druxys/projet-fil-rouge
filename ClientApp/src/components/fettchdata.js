import React, { useEffect, useState } from 'react';


export const Fettchdata = (props ) => {
  
    const [forecasts, setForecasts] = useState();

    console.log(forecasts);
    const populateWeatherData =   async () => {
        const response = await fetch('testcontroller');
        const data = await response.json();
        setForecasts(data);
    }

    useEffect(() => {
        populateWeatherData();
    },[]);

    return (

        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
              {forecasts?.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>
    )


}