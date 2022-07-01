import React, { Component } from 'react';

import {
    Typography
} from '@mui/material';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <>
                <Typography variant="h1" component="h1">
                    Gestion de production
                </Typography>
                <Typography mt="2rem" variant="h5" component="h5">
                    Une application intuitive pour permettre aux entreprises de produire simplement
                </Typography>

                <Typography mt="2rem" variant="h6" component="h6">
                    Dorian Legros & Paul turpin & Ahmed Bouknana
                </Typography>

            </>
        );
    }
}
