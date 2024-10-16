import React from 'react'
import './header.css'
import { Button } from '@mui/material'

export default function Header() {
    let coverPhoto= "/Home%20Wallpaper1.png"
    let text = {header: 'web development services',
                body: 'we design and build mindustry-leading web-based products to improve your business'
    }
  return (
    <header style={{backgroundImage: `url(${coverPhoto})`}}>
      <div className='header-text'>
        <h2>
          {text.header}
        </h2>
        <p>
          {text.body}
        </p>
        <Button variant='outlined' color='#F58634'>Join Us</Button>
      </div>
    </header>
  )
}
