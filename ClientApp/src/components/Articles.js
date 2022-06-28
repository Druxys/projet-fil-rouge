import React, { useEffect, useState } from 'react';

import { useHistory } from 'react-router-dom';
import { DataGrid } from '@mui/x-data-grid';
import DeleteIcon from '@mui/icons-material/Delete';
import IconButton from '@mui/material/IconButton';

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

    const columns = [
        { field: 'id', headerName: 'ID', width: 70 },
        { field: 'code', headerName: 'Code', width: 130 },
        { field: 'libelle', headerName: 'Libellé', width: 130 },
        {
            field: 'categorie',
            headerName: 'Catégorie',
            width: 90,
        },
        {
            field: 'action',
            headerName: 'Actions',
            sortable: false,
            width: 160,
            renderCell: (params) => (
                <IconButton onClick={() => alert("delete")}>
                    <DeleteIcon />
                </IconButton>
            )
         
        },
    ];

    console.log(articles)
    return (
        <DataGrid
        rows={!!articles ? articles : []}
        columns={columns}
        pageSize={20}
        rowsPerPageOptions={[5]}
     
            onRowClick={(e) => {
                handleDetail(e.id);
            }}

      />
        //<table className='table table-striped table-hover' aria-labelledby="tabelLabel">
        //    <thead>
        //        <tr>
        //            <th>Code</th>
        //            <th>Libellé</th>
        //            <th>Catégorie</th>
        //            <th>Actions</th>
        //        </tr>
        //    </thead>
        //    <tbody>
        //        {articles?.map(article =>
        //            <tr key={article.id}
        //                onClick={(e) => {
        //                    console.log("lala" + article.id)
        //                    e.stopPropagation();
        //                    handleDetail(article.id);
        //                }}>
        //                <td>{article.code}</td>
        //                <td>{article.libelle}</td>
        //                <td>{article.id_categorie}</td>
        //                <td>
        //                    <button type="button" className="btn btn-primary"><i className="far fa-eye"></i></button>
        //                    <button type="button" className="btn btn-success"><i className="fas fa-edit"></i></button>
        //                    <button type="button" className="btn btn-danger"><i className="far fa-trash-alt"></i></button>
        //                </td>
        //            </tr>
        //        )}
        //    </tbody>
        //</table>
    )


}