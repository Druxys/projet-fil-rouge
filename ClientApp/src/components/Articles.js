import React, { useEffect, useState } from 'react';

import { useHistory } from 'react-router-dom';

export const Articles = (props) => {
    let history = useHistory();
    const [articles, setArticles] = useState();
    const handleDetail = (id) => {
        history.push(`/article/${id}`)
    };

    const getArticlesData = async () => {
        const response = await fetch('articles');
        const data = await response.json();
        const resultData = JSON.parse(data)
 
        setArticles(resultData);
    }

    useEffect(() => {

        getArticlesData();

    }, []);

    return (

        <table className='table table-striped table-hover' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Code</th>
                    <th>Libellé</th>
                    <th>Catégorie</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {articles?.map(article =>
                    <tr key={article.id}
                        onClick={(e) => {
                            console.log("lala" + article.id)
                        e.stopPropagation();
                        handleDetail(article.id);
                    }}>
                        <td>{article.code}</td>
                        <td>{article.libelle}</td>
                        <td>{article.id_categorie}</td>
                        <td>
                            <button type="button" className="btn btn-primary"><i className="far fa-eye"></i></button>
                            <button type="button" className="btn btn-success"><i className="fas fa-edit"></i></button>
                            <button type="button" className="btn btn-danger"><i className="far fa-trash-alt"></i></button>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    )


}