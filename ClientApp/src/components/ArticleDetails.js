import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useForm } from "react-hook-form";
import { Box, Grid, Button, TextField, InputLabel, FormControl, Typography } from '@mui/material';

const axios = require('axios');
export const ArticleDetails = (props) => {
    const [formProd, setformProd] = useState(false)
    const [article, setArticle] = useState();
    const [quantite, setQuantite] = useState()
    let { id } = useParams();
    console.log(id);
    const { register, handleSubmit } = useForm();


    const getData = () => {
        axios({
            url: `articles/byId/${id}`,
            method: "GET",
        }).then(data => setArticle(JSON.parse(data.data)))
            .catch(error => console.log(error));
    };

    useEffect(() => {
        getData();
    }, []);
    console.log(formProd);

    const handleChangeQuantite = (e) => {
        setQuantite(e.target.value)
    };

    const showFormProd = () => {
        !!formProd ? setformProd(false) : setformProd(true);
    }

    const onSubmit = (data) => {
        console.log(article.id)
        console.log(data)
        const id = article.id;
        const quantity = data.quantite;

        axios.post(`articles/product/${id}/${quantity}`, { params: { id, quantity }}, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                console.log("Status: ", response.status);
                console.log("Data: ", response.data);
            }).catch(error => {
                console.error('Something went wrong!', error);
            });
    };

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
                <Grid mb="2rem" item xs={6}>
                    <Button variant="contained" onClick={() => showFormProd()}>Lancer la production</Button>
                </Grid>
                {!!formProd && (
                    <form onSubmit={handleSubmit(onSubmit)}>
                        <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                        <Grid item xs={12}>
                            <TextField
                                fullWidth
                                id="quantiteNumber"
                                label="Number"
                                type="number"
                                value={quantite}
                                {...register("quantite")}
                                onChange={handleChangeQuantite}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <input type="submit" />
                            </Grid>
                        </Grid>
                    </form>
                )}
            </Grid>
        </Box>

    )


}