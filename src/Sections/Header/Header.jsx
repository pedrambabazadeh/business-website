import React from 'react'
import './header.css'

export default function Header() {
    let coverPhoto= "/Home%20Wallpaper.png"
    let text = {header: 'web development services',
                body: 'we design and build mindustry-leading web-based products to improve your business'
    }
  return (
    <header style={{backgroundImage: `url(${coverPhoto})`}}>
      <div>
        <h2>
          {text.header}
        </h2>
        <p>
          {text.body}
        </p>
      </div>
    </header>
  )
}
