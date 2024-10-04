import React from 'react'
import { Grid, Box } from '@mui/material';

export default function NavigationSec() {
  return (
    <Grid container spacing={4}>
      <Grid item xs={6}>
     <Box p={2}>Hello</Box> </Grid>
      <Grid item xs={4}>
      <Box  p={2}>Hello</Box>
      </Grid>
      <Grid item xs={2}>
      <Box  p={2}>Hello</Box>
      </Grid>
    </Grid>
  )
}
