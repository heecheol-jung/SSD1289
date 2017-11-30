#include "main.h"
#include "stm32f4xx_hal.h"
#include "usart.h"
#include "gpio.h"
#include "fsmc.h"
#include "ssd1289.h"

#define _SSD1289_LCD_REG      (*((volatile unsigned short *) 0x6F000000)) /* RS = 0 */
#define _SSD1289_LCD_RAM      (*((volatile unsigned short *) 0x6F010000)) /* RS = 1 */

__INLINE void _ssd1289_write_addr(uint8_t reg)
{
  _SSD1289_LCD_REG = (uint16_t)reg;
}

__INLINE uint16_t _ssd1289_read_data(void)
{
  return (uint16_t)_SSD1289_LCD_RAM;
}

__INLINE void _ssd1289_write_data(uint16_t data)
{
  _SSD1289_LCD_RAM = data;
}

uint16_t ssd1289_read_reg(uint8_t reg)
{
  _ssd1289_write_addr(reg);
  
  return _ssd1289_read_data();
}

void ssd1289_write_reg(uint8_t reg, uint16_t regValue)
{
  _ssd1289_write_addr(reg);
  
  _ssd1289_write_data(regValue);
}
