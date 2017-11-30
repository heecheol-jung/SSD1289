#ifndef __SSD1298_H
#define __SSD1298_H

#define SSD1289_ID            (0x8989)

uint16_t ssd1289_read_reg(uint8_t reg);
void ssd1289_write_reg(uint8_t reg, uint16_t regValue);

#endif
