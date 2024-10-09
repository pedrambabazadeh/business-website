import React from 'react'
import './header.css'

export default function Header() {
    let coverPhoto= "/Home%20Wallpaper.png"
  return (
    <header style={{backgroundImage: `url(${coverPhoto})`}}></header>
  )
}
