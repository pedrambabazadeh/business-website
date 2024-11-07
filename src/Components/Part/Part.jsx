import React from 'react'
import './part.css'
import { Button, Grid, Box } from '@mui/material'

export default function Part(props) {
  return (
    <section className='main-section'>
      <h3>{props.title}</h3>
      <div className='separator'
          style={{backgroundColor: props.color,
          boxShadow: `3px 0px 5px ${props.color}, -3px -0px 5px ${props.color}`}}>
          &nbsp;
      </div>
      <Grid container>
        <Grid item xs={7}>
          <Box>
            <p>{props.data}</p>
          </Box>
        </Grid>
        {props.children}
      </Grid>
    </section>
  )
}
