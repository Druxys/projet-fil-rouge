import React, { useEffect, useState } from 'react';

import { useHistory } from 'react-router-dom';
import { DataGrid } from '@mui/x-data-grid';


import {
    Grid,
    Typography
} from '@mui/material';
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
    const localizedTextsMap = {
        columnMenuUnsort: "Sans tri",
        columnMenuSortAsc: "Trier par ASC",
        columnMenuSortDesc: "Trier par DESC",
        columnMenuFilter: "Filtrer",
        columnMenuHideColumn: "Masquer colonne",
        columnMenuShowColumns: "Afficher colonne"
    };

    const columns = [
        { field: 'Id', headerName: 'ID', width: 70 },
        { field: 'Code', headerName: 'Code', width: 130 },
        { field: 'Label', headerName: 'Libellé', width: 130 },
        {
            field: 'CategoryId',
            headerName: 'Catégorie',
            width: 90,
        },
        //{
        //    field: 'action',
        //    headerName: 'Actions',
        //    sortable: false,
        //    width: 160,
        //    renderCell: (params) => (
        //        <IconButton onClick={() => alert("delete")}>
        //            <DeleteIcon />
        //        </IconButton>
        //    )

        //},
    ];

    return (
        <>
            {!articles ?
                <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid mb="2rem" item xs={12}>
                        <Typography variant="h4" component="h3">
                            Pas de données
                        </Typography>
                    </Grid>
                </Grid> :
                <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid mb="2rem" item xs={12}>
                        <DataGrid
                            rows={!!articles ? articles : []}
                            columns={columns}
                            pageSize={20}
                            autoHeight
                            rowsPerPageOptions={[5]}
                            localeText={localizedTextsMap}
                            onRowClick={(e) => {
                                handleDetail(e.id);
                            }}

                        />
                    </Grid>
                </Grid> 
               
            }

        </>

    )
}

