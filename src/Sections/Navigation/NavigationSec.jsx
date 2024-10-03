import React from 'react'
import { Grid, Box } from '@mui/material';

export default function NavigationSec() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={6}>
     <Box bgcolor="lightyellow" p={2}>Hello</Box> </Grid>
      <Grid item xs={6}>
      <Box bgcolor="lightyellow" p={2}>Hello</Box>
      </Grid>
    </Grid>
  )
}
