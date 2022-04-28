import React, { useEffect, useState } from 'react';


export const Articles = (props) => {

    const [articles, setArticles] = useState();

    const getArticlesData = async () => {
        const response = await fetch('ArticlesContoller');
        const data = await response.json();
        setArticles(data);
    }

    useEffect(() => {
        getArticlesData();
 
    }, []);

    return (

        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Code</th>
                    <th>Libellé</th>
                    <th>Catégorie</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {articles?.map(article =>
                    <tr key={article.id}>
                        <td>{article.id}</td>
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