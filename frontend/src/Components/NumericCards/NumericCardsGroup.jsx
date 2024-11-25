import React from 'react'
import SingleCard from './SingleCard'
import './numeric-cards.css'
import { Grid2 as Grid, Box } from '@mui/material'

export default function NumericCardsGroup() {
  return (
    <Grid container spacing={2} justifyContent={'center'}>
      <Grid size={{xs: 2}}>
        <SingleCard title="customers" data="1234"/>
      </Grid>
      <Grid size={{xs: 2}}>
        <SingleCard title="test" data="1234"/>
      </Grid>
      <Grid size={{xs: 2}}>
        <SingleCard title="test" data="1234"/>
      </Grid>
      <Grid size={{xs: 2}}>
        <SingleCard title="test" data="1234"/>
      </Grid>
    </Grid>
  )
}
