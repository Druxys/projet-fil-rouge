import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { Container, Row, Col } from "reactstrap";
import TemporaryDrawer from './sideBar';
import { Box, Grid } from '@mui/material';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <Box sx={{ flexGrow: 1 }} mt="10rem">
                <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid mb="5rem" item xs={1}>
                        <TemporaryDrawer />
                    </Grid>
                    <Grid mb="2rem" item xs={9} >
                        {this.props.children}
                    </Grid>
                    <Grid mb="2rem" item xs={2} >
                     
                    </Grid>
                </Grid>
            </Box >

        );
    }
}
