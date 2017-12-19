#ifndef __SSD1298_H
#define __SSD1298_H

#define SSD1289_REG_DEV_CODE_READ       (0x00)
#define SSD1289_REG_OSC                 (0x00)
#define SSD1289_REG_DRV_OUT_CTRL        (0x01)
#define SSD1289_REG_LCD_DRV_WVFRM_CTRL  (0x02)
#define SSD1289_REG_PWR_CTRL1           (0x03)
#define SSD1289_REG_CMP1                (0x05)
#define SSD1289_REG_CMP2                (0x06)
#define SSD1289_REG_DISP_CTRL           (0x07)
#define SSD1289_REG_FRM_CYCLE_CTRL      (0x0B)
#define SSD1289_REG_PWR_CTRL2           (0x0C)
#define SSD1289_REG_PWR_CTRL3           (0x0D)
#define SSD1289_REG_PWR_CTRL4           (0x0E)
#define SSD1289_REG_GATE_SCAN_POS       (0x0F)
#define SSD1289_REG_ENTRY_MODE          (0x11)
#define SSD1289_REG_OPT_DATA_ACS_SPEED1 (0x12)
#define SSD1289_REG_GENERIC_IF_CTRL     (0x15)
#define SSD1289_REG_H_PORCH             (0x16)
#define SSD1289_REG_V_PORCH             (0x17)
#define SSD1289_REG_PWR_CTRL5           (0x1E)
#define SSD1289_REG_WD_TO_GRAM          (0x22)
#define SSD1289_REG_RD_FROM_GRAM        (0x22)
#define SSD1289_REG_RAM_W_MASK1         (0x23)
#define SSD1289_REG_RAM_W_MASK2         (0x24)
#define SSD1289_REG_FRM_FREQ_CTRL       (0x25)
#define SSD1289_REG_VCOM_OTP1           (0x28)
#define SSD1289_REG_OPT_DATA_ACS_SPEED2 (0x28)
#define SSD1289_REG_VCOM_OTP2           (0x29)
#define SSD1289_REG_OPT_DATA_ACS_SPEED3 (0x2F)
#define SSD1289_REG_GAMMA_CTRL1         (0x30)
#define SSD1289_REG_GAMMA_CTRL2         (0x31)
#define SSD1289_REG_GAMMA_CTRL3         (0x32)
#define SSD1289_REG_GAMMA_CTRL4         (0x33)
#define SSD1289_REG_GAMMA_CTRL5         (0x34)
#define SSD1289_REG_GAMMA_CTRL6         (0x35)
#define SSD1289_REG_GAMMA_CTRL7         (0x36)
#define SSD1289_REG_GAMMA_CTRL8         (0x37)
#define SSD1289_REG_GAMMA_CTRL9         (0x3A)
#define SSD1289_REG_GAMMA_CTRL10        (0x3B)
#define SSD1289_REG_V_SCROLL_CTRL1      (0x41)
#define SSD1289_REG_V_SCROLL_CTRL2      (0x42)
#define SSD1289_REG_H_RAM_ADDR_POS      (0x44)
#define SSD1289_REG_V_RAM_ADDR_POS1     (0x45)
#define SSD1289_REG_V_RAM_ADDR_POS2     (0x46)
#define SSD1289_REG_S1_DRV_POS1         (0x48)
#define SSD1289_REG_S1_DRV_POS2         (0x49)
#define SSD1289_REG_S2_DRV_POS1         (0x4A)
#define SSD1289_REG_S2_DRV_POS2         (0x4B)
#define SSD1289_REG_RAM_ADDR_SET1       (0x4E)
#define SSD1289_REG_RAM_ADDR_SET2       (0x4F)

#define SSD1289_MASK_R00_OSCEN          (0x0001)
#define SSD1289_OFFSET_R00_OSCEN        (0x0000)

#define SSD1289_MASK_R01_MUX            (0x01FF)
#define SSD1289_OFFSET_R01_MUX          (0)
#define SSD1289_MASK_R01_TB             (0x0200)
#define SSD1289_OFFSET_R01_TB           (9)

#define SSD1289_MASK_
#define SSD1289_OFFSET_

#define SSD1289_ID            (0x8989)

uint16_t ssd1289_read_reg(uint8_t reg);
void ssd1289_write_reg(uint8_t reg, uint16_t regValue);

#endif
