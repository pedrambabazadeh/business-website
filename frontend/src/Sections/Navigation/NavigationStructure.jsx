import React from 'react'
import { Grid, Box } from '@mui/material';
import { Search, Menu } from '@mui/icons-material';

export default function NavigationStructure(props) {
  return (
    <Grid container spacing={4}>
      <Grid item xs={5}>
     <Box className='left-nav' p={2}> {props.left}</Box> </Grid>
      <Grid item xs={5}>
      <Box  p={2}>{props.center}</Box>
      </Grid>
      <Grid item xs={2}>
      <Box  p={2}>
        <Grid item>
          <Grid item xs={12}>
              <Box p={2}>
                <Grid container spacing={4}>
                  <Grid item xs={12}>
                    <Box>
                      <Search/>
                      <Menu/>
                    </Box>
                  </Grid>
                </Grid>
              </Box>
          </Grid>
        </Grid>
      </Box>
      </Grid>
    </Grid>
  )
}
