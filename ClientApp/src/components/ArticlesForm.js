import React, { useState, useEffect, useRef } from "react";
import { useForm } from "react-hook-form";
import {
    Box, Button, Grid, TextField, Select,
    InputLabel, Fab, FormControl,
    Typography, MenuItem
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
const axios = require('axios');
export const ArticlesForm = (props) => {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [articles, setArticles] = useState();
    const [categories, setCategories] = useState();
    const [operations, setOperations] = useState();
    const [dataList, setDataList] = useState([{ codeArticle: '', quantite: '' }]);

    const [operationValue, setOperationValue] = useState()
    const [categoryValue, setCategoryValue] = useState()

    //console.log(watch("example")); // watch input value by passing the name of it


    const getArticlesData = async () => {
        const response = await fetch('articles');
        const data = await response.json();
        const resultData = JSON.parse(data)
        setArticles(resultData);
    }

    useEffect(() => {
        getArticlesData();
    }, []);

    const getCategoriesData = async () => {
        const response = await fetch('categories');
        const data = await response.json();
        const resultData = JSON.parse(data)
        setCategories(resultData);
    }
    //console.log(dataList)
    useEffect(() => {
        getCategoriesData();
    }, []);

    const getOperationsData = async () => {
        const response = await fetch('operations');
        const data = await response.json();
        const resultData = JSON.parse(data)
        setOperations(resultData);
    }

    useEffect(() => {
        getOperationsData();
    }, []);

    const articleOptions = articles?.map((article) => ({
        label: article.code,
        value: article.id,
    }));


    const categoryOptions = categories?.map((category) => ({
        label: category.libelle,
        value: category.code,
    }));

    const operationOptions = operations?.map((operation) => ({
        label: operation.libelle,
        value: operation.code,
    }));




    const handleChange = (e, index) => {
        const { name, value } = e.target;
        const list = [...dataList];
        list[index][name] = value;
        setDataList(list)
    };

    const handleChangeQuantity = (e, index) => {
        const { name, value } = e.target;
        const list = [...dataList];
        list[index][name] = value;
        setDataList(list)
    };

    const handleChangeOperation = (e) => {
        setOperationValue(e.target.value)
    };

    const handleChangeCategory = (e) => {
        setCategoryValue(e.target.value)
    };

    const handleDatalistAdd = () => {
        setDataList([...dataList, { codeArticle: '', quantite: '' }])
    }

    const handleDatalistRemove = (index) => {
        const list = [...dataList]
        list.splice(index, 1)
        setDataList(list)
    }


    const onSubmit = (data) => {
        const articles = { articles: dataList }
        const { codeCategorie, codeArticleNew, codeOperation } = data
        const codeArticle = codeArticleNew
        const values = { ...articles, codeCategorie, codeArticle, codeOperation }

     
        const result = JSON.stringify(values);
        const articleJson = JSON.stringify(result).toString();
        console.log(articleJson);
        console.log(result);

        axios.post('articles', articleJson, {
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

    const ref0 = useRef();
    return (
        <Box sx={{ flexGrow: 1 }} mt="10rem">
            <form onSubmit={handleSubmit(onSubmit)}>
                <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid mb="2rem" item xs={12}>
                        <Typography variant="h4" component="h3">
                            Informations sur l'article
                        </Typography>
                    </Grid>
                    <Grid item xs={6}>
                        <TextField fullWidth {...register("name")} label="Nom de larticle" />
                    </Grid>
                    <Grid item xs={6}>
                        <TextField fullWidth  {...register("codeArticleNew", { required: true })} label="Code article" />
                        {errors.exampleRequired && <span>This field is required</span>}
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth >
                            <InputLabel id="codeCategorie">Catégorie</InputLabel>

                            <Select
                                labelId="codeCategorie"
                                value={categoryValue}
                                onChange={handleChangeCategory}
                                fullWidth
                                {...register("codeCategorie")}

                            >
                                {categoryOptions?.map((category) => {
                                    return (
                                        <MenuItem key={category?.value} value={category?.label}>
                                            {category?.value}
                                        </MenuItem>
                                    )
                                }
                                )
                                }
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid mb="2rem" mt="2rem" item xs={12}>
                        <Typography variant="h4" component="h3">
                            Recette de l'article
                        </Typography>
                    </Grid>

                    {dataList.map((element, index) => (
                        <>
                            <Grid container spacing={3} ml="5px" key={index}>
                                <Grid mb="2rem" item xs={5}>
                                    <FormControl fullWidth>
                                        <InputLabel id="articleId">Articles</InputLabel>
                                        {/*<Autocomplete*/}
                                        {/*    disablePortal*/}
                                        {/*    name="codeArticle"*/}
                                        {/*    options={!!articleOptions ? articleOptions : []}*/}
                                        {/*    ref={ref0}*/}
                                        {/*    onChange={(e, v, r, name) => {*/}
                                        {/*        name =ref0?.current?.getAttribute("name")*/}
                                        {/*        console.log(ref0?.current?.getAttribute("name"));*/}
                                        {/*    }}*/}


                                        {/*    renderInput={(params) => <TextField {...params} onChange={(e) => console.log('lala')} label="codeArticle" />}*/}
                                        {/*/>*/}
                                        <Select
                                            labelId="articleId"
                                            value={element?.codeArticle}
                                            onChange={(e) => handleChange(e, index)}
                                            inputProps={register('codeArticle')}

                                        >
                                            {articleOptions?.map((article) => {
                                                return (
                                                    <MenuItem key={article?.value} value={article?.label}>
                                                        {article?.label}
                                                    </MenuItem>
                                                )
                                            }
                                            )};
                                        </Select>
                                    </FormControl>
                                </Grid>
                                <Grid item xs={5}>
                                    <TextField
                                        fullWidth
                                        id="quantiteNumber"
                                        label="Number"
                                        type="number"
                                        value={element?.quantite}
                                        {...register("quantite")}
                                        onChange={(e) => handleChangeQuantity(e, index)}
                                        InputLabelProps={{
                                            shrink: true,
                                        }}
                                    />
                                </Grid>
                                {dataList.length > 1 && (
                                    <Grid item xs={2}>
                                        <Button variant="contained" onClick={() => handleDatalistRemove(index)}>Supprimer</Button>
                                    </Grid>
                                )}


                                {dataList.length - 1 === index && dataList.length < 2 && (
                                    <Box >
                                        <Typography variant="h6" component="h6">
                                            Ajouter un composant
                                        </Typography>
                                        <Fab color="primary" onClick={handleDatalistAdd} aria-label="add">
                                            <AddIcon />
                                        </Fab>
                                    </Box>

                                )}
                            </Grid>

                        </>
                    ))}
                    <Grid item xs={12}>
                        <FormControl fullWidth >
                            <InputLabel id="codeOperation">Opération</InputLabel>

                            <Select
                                labelId="codeOperation"
                                value={operationValue}
                                onChange={handleChangeOperation}
                                fullWidth
                                {...register("codeOperation")}
                            >
                                {operationOptions?.map((operation) => {
                                    return (
                                        <MenuItem key={operation?.value} value={operation?.value}>
                                            {operation?.label}
                                        </MenuItem>
                                    )
                                }
                                )
                                }
                            </Select>
                        </FormControl>
                    </Grid>
                    <Grid item xs={6}>
                        <input type="submit" />
                    </Grid>
                </Grid>

            </form>
        </Box>
    );
}