import React from 'react'
import { Grid, Box } from '@mui/material';

export default function NavigationStructure(props) {
  return (
    <Grid container spacing={4}>
      <Grid item xs={5}>
     <Box p={2}> {props.left}</Box> </Grid>
      <Grid item xs={5}>
      <Box  p={2}>{props.center}</Box>
      </Grid>
      <Grid item xs={2}>
      <Box  p={2}>Hello</Box>
      </Grid>
    </Grid>
  )
}
