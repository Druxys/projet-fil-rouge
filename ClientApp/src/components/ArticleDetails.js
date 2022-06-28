import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Box, Grid, TextField, InputLabel, FormControl, Typography } from '@mui/material';

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
        <Box sx={{ flexGrow: 1 }} mt="10rem">
            <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                <Grid mb="2rem" item xs={12}>
                    <Typography variant="h4" component="h3">
                        Détails de l'article
                    </Typography>
                </Grid>
                <Grid mb="2rem" item xs={6}>
                    <Typography variant="h6" component="h6">
                        Catégorie
                    </Typography>
                    <TextField labelId="codeCategorie" disabled fullWidth value={article?.Code} />

                </Grid>
                <Grid mb="2rem" item xs={6}>
                    <Typography variant="h6" component="h6">
                        Libellé
                    </Typography>
                    <TextField disabled fullWidth value={article?.libelle} />
                </Grid>
                <Grid mb="2rem" item xs={6}>
                    <Typography variant="h6" component="h6">
                        Id
                    </Typography>
                    <TextField disabled fullWidth value={article?.id} />
                </Grid>
                <Grid mb="2rem" item xs={6}>
                    <Typography variant="h6" component="h6">
                        IdCatégorie
                    </Typography>
                    <TextField disabled fullWidth value={article?.id_categorie} />
                </Grid>
            </Grid>
        </Box>
        //<table className='table table-striped table-hover' aria-labelledby="tabelLabel">
        //    <thead>
        //        <tr>
        //            <th>Code</th>
        //            <th>Libellé</th>
        //            <th>Catégorie</th>

        //        </tr>
        //    </thead>
        //    <tbody>

        //            <tr key={article?.id}>
        //                <td>{article?.code}</td>
        //                <td>{article?.libelle}</td>
        //                <td>{article?.id_categorie}</td>

        //          </tr>

        //    </tbody>
        //</table>
    )


}