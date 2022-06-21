import React, { useEffect, useState } from 'react';
import { Routes, Route, useParams } from 'react-router-dom';
const axios = require('axios');
export const ArticleDetails = (props) => {

    const [article, setArticle] = useState();

    let { id } = useParams();
    console.log(id);


    const getData = () => {
        axios({
            url: `articles/byId/${id}`,
            method: "GET",
            headers: { "Access-Control-Allow-Origin": "*" },
        }).then(data => setArticle(JSON.parse(data.data)))
          .catch(error => console.log(error));
    };
    console.log(article)
    useEffect(() => {
        getData();
    }, []);

    return (

        <table className='table table-striped table-hover' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Code</th>
                    <th>Libellé</th>
                    <th>Catégorie</th>
       
                </tr>
            </thead>
            <tbody>
               
                    <tr key={article?.id}>
                        <td>{article?.code}</td>
                        <td>{article?.libelle}</td>
                        <td>{article?.id_categorie}</td>
                       
                  </tr>
               
            </tbody>
        </table>
    )


}